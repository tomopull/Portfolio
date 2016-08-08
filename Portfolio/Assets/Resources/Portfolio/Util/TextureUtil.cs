using UnityEngine;
using System.Collections;
using System.IO;

public class TextureUtil  {

	//UnityでPNGファイルを動的に読み込む
	public static Texture2D ReadTexture(string path)
	{
		byte[] readBinary = ReadPngFile(path);

		int pos = 16; // 16バイトから開始

		int width = 0;
		for (int i = 0; i < 4; i++)
		{
			width = width * 256 + readBinary[pos++];
		}

		int height = 0;
		for (int i = 0; i < 4; i++)
		{
			height = height * 256 + readBinary[pos++];
		}

		Texture2D texture = new Texture2D(width, height);
		texture.LoadImage(readBinary);

		return texture;
	}
	
	//UnityでPNGファイルを動的に読み込む(サイズ指定)
	public static Texture ReadTextureWithSize(string path, int width, int height){
		byte[] readBinary = ReadPngFile(path);

		Texture2D texture = new Texture2D(width, height);
		texture.LoadImage(readBinary);

		return texture;
	}

	static private byte[] ReadPngFile(string path){
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader bin = new BinaryReader(fileStream);
		byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

		bin.Close();

		return values;	
	}

}
