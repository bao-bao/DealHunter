// DbTransdll.h

#pragma once

using namespace System;

namespace DbTransdll {

	public ref class GoodsTrans
	{
		// TODO:  在此处添加此类的方法。
	public:
		static String typetrans(String dbtype)
		{
			if (dbtype == "0"->ToString)
			{
				return "在售"->ToString;
			}
			if (dbtype == "1"->ToString)
			{
				return "结售"->ToString;
			}
			return "状态获取错误"->ToString;
		}

		static String timetrans(DateTime dbtime)
		{
			return dbtime.ToString;
		}
	};
}
