// DbTransdll.h

#pragma once

using namespace System;

namespace DbTransdll {

	public ref class GoodsTrans
	{
		// TODO:  在此处添加此类的方法。
	public:
		static String ^typetrans(String ^dbtype)
		{
			String ^s1 = gcnew String("0");
			String ^s2 = gcnew String("1");
			String ^s3 = gcnew String("在售");
			String ^s4 = gcnew String("结售");
			String ^s5 = gcnew String("状态获取错误");
			if (dbtype == s1)
			{
				return s3;
			}
			if (dbtype == s2)
			{
				return s4;
			}
			return s5;
		}

		static String ^timetrans(DateTime ^dbtime)
		{
			return dbtime->ToString();
		}
	};
}
