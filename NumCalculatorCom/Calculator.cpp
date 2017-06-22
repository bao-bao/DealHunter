// Calculator.cpp : CCalculator µÄÊµÏÖ

#include "stdafx.h"
#include "Calculator.h"


// CCalculator



STDMETHODIMP CCalculator::Add(LONG val1, LONG val2, LONG* result)
{
	*result = val1 + val2;
	return S_OK;
}


STDMETHODIMP CCalculator::Sub(LONG val1, LONG val2, LONG* result)
{
	*result = val1 - val2;
	return S_OK;
}


STDMETHODIMP CCalculator::Mul(LONG val1, LONG val2, LONG* result)
{
	*result = val1 * val2;
	return S_OK;
}

STDMETHODIMP CCalculator::Div(LONG val1, LONG val2, LONG* result)
{
	*result = val1 / val2;
	return S_OK;
}