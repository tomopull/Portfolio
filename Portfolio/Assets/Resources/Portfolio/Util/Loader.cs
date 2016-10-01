using UnityEngine;
using System.Collections.Generic;

public static class Loader
{
    private static readonly Dictionary<string, Texture> mList = new Dictionary<string, Texture>();

    public static Texture Load( string path )
    {
        if ( !mList.ContainsKey( path ) )
        {
            mList[ path ] = Resources.Load<Texture>( path );
        }
        return mList[ path ];
    }

    public static void Clear()
    {
        mList.Clear();
    }
}