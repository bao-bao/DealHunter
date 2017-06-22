// DBTranswin32dll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include <string>


extern "C" __declspec(dllexport) string GtypeToDb(string )
{
	return x + y;
}

extern "C" __declspec(dllexport) int Sub(int x, int y)
{
	return x - y;
}