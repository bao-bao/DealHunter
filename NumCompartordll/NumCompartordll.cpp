// NumCompartordll.cpp : ���� DLL Ӧ�ó���ĵ���������
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
