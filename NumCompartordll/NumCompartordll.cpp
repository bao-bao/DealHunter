// NumCompartordll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"

extern "C" __declspec(dllexport) int dhintCompare(int x, int y)
{
	if (x > y)
	{
		return 1;
	}
	if (x == y)
	{
		return 0;
	}
	return -1;
}
