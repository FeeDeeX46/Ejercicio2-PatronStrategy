using System;

namespace PrimeraFecha
{
	public class TallerDeChapaYPintura: Negocio
	{
		IStrategy strategy;
		
		public void setStrategy(IStrategy strategy)
		{
			this.strategy = strategy;
		}
		
		protected override IEmpleado algunEmpleado()
		{
			return strategy.elegirEmpleado(this.empleados);
		}
	}
}
