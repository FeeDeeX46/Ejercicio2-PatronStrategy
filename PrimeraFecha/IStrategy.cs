using System;
using System.Collections.Generic;

namespace PrimeraFecha
{
	public interface IStrategy
	{
		IEmpleado elegirEmpleado(List<IEmpleado> empleados);
	}
}
