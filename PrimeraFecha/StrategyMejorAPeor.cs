using System;
using System.Collections.Generic;

namespace PrimeraFecha
{
	public class StrategyMejorAPeor: IStrategy
	{
		public IEmpleado elegirEmpleado(List<IEmpleado> empleados)
		{
			int i = 0;
			while (i < empleados.Count-1)
			{
				if (empleados[i].getExperiencia() < empleados[i + 1].getExperiencia())
				{
					IEmpleado auxiliar = empleados[i];
					empleados[i] = empleados[i + 1];
					empleados[i + 1] = auxiliar;
					i = 0;
				}
				else
				{
					i++;
				}
			}
			return empleados[i];
		}
	}
}
