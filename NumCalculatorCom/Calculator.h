// Calculator.h : CCalculator ������

#pragma once
#include "resource.h"       // ������



#include "NumCalculatorCom_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif

using namespace ATL;


// CCalculator

class ATL_NO_VTABLE CCalculator :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCalculator, &CLSID_Calculator>,
	public IDispatchImpl<ICalculator, &IID_ICalculator, &LIBID_NumCalculatorComLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCalculator()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CALCULATOR)


BEGIN_COM_MAP(CCalculator)
	COM_INTERFACE_ENTRY(ICalculator)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:



	STDMETHOD(Add)(LONG val1, LONG val2, LONG* result);
	STDMETHOD(Sub)(LONG val1, LONG val2, LONG* result);
	STDMETHOD(Mul)(LONG val1, LONG val2, LONG* result);
	STDMETHOD(Div)(LONG val1, LONG val2, LONG* result);
};

OBJECT_ENTRY_AUTO(__uuidof(Calculator), CCalculator)
