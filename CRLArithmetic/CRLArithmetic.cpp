#include "pch.h"

#include "CRLArithmetic.h"
#include <cmath>
#include <exception>

namespace CRLArithmetic {
	double Arithmetic::Percenatage(double source, double source2)
	{
		return source * source2 / 100;
	}
	double Arithmetic::DoubleSquare(double source)
	{
		return pow(source,2);
	}
	double Arithmetic::Root(double source)
	{
		return sqrt(source);
	}
	double Arithmetic::OneInNum(double source)
	{
		if (source == 0) {
			throw gcnew DivideByZeroException();
		}
		else {
			return 1 / source;
		}
	}
}
