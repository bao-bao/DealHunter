// DbTransdll.h

#pragma once

using namespace System;

namespace DbTransdll {

	public ref class GoodsTrans
	{
		// TODO:  �ڴ˴���Ӵ���ķ�����
	public:
		static String typetrans(String dbtype)
		{
			if (dbtype == "0"->ToString)
			{
				return "����"->ToString;
			}
			if (dbtype == "1"->ToString)
			{
				return "����"->ToString;
			}
			return "״̬��ȡ����"->ToString;
		}

		static String timetrans(DateTime dbtime)
		{
			return dbtime.ToString;
		}
	};
}
