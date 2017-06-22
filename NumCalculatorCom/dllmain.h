// dllmain.h: 模块类的声明。

class CNumCalculatorComModule : public ATL::CAtlDllModuleT< CNumCalculatorComModule >
{
public :
	DECLARE_LIBID(LIBID_NumCalculatorComLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_NUMCALCULATORCOM, "{EB698315-24C0-4E12-8D84-C3332F29E62C}")
};

extern class CNumCalculatorComModule _AtlModule;
