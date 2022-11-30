using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Kogane
{
    /// <summary>
    /// ScriptableSingleton 型の拡張メソッド
    /// </summary>
    public static class ScriptableSingletonExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// protected な Save 関数を public で呼び出せるようにする拡張メソッド
        /// </summary>
        public static void Save<T>( this ScriptableSingleton<T> self, bool saveAsText ) where T : ScriptableObject
        {
            var type       = typeof( ScriptableSingleton<T> );
            var methodInfo = type.GetMethod( "Save", BindingFlags.NonPublic | BindingFlags.Instance );

            Assert.IsNotNull( methodInfo );

            methodInfo.Invoke( self, new object[] { saveAsText } );
        }
    }
}