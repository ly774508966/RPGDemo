﻿
using System;
using System.Collections.Generic;
using LuaInterface;

namespace SLua
{
    public partial class LuaDelegation : LuaObject
    {

        static internal int checkDelegate(IntPtr l,int p,out Callback<System.String,UnityEngine.AssetBundle,object> ua) {
            int op = extractFunction(l,p);
			if(LuaDLL.lua_isnil(l,p)) {
				ua=null;
				return op;
			}
            else if (LuaDLL.lua_isuserdata(l, p)==1)
            {
                ua = (Callback<System.String,UnityEngine.AssetBundle,object>)checkObj(l, p);
                return op;
            }
            LuaDelegate ld;
            checkType(l, -1, out ld);
            if(ld.d!=null)
            {
                ua = (Callback<System.String,UnityEngine.AssetBundle,object>)ld.d;
                return op;
            }
			LuaDLL.lua_pop(l,1);
			
			l = LuaState.get(l).L;
            ua = (string a1,UnityEngine.AssetBundle a2,System.Object a3) =>
            {
                int error = pushTry(l);

				pushValue(l,a1);
				pushValue(l,a2);
				pushValue(l,a3);
				ld.pcall(3, error);
				LuaDLL.lua_settop(l, error-1);
			};
			ld.d=ua;
			return op;
		}
	}
}
