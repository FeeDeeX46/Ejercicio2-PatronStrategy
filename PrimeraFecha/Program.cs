using System;

namespace PrimeraFecha
{
	class Program
	{
		public static void Main(string[] args)
		{
			TallerDeChapaYPintura taller = new TallerDeChapaYPintura();
			
			Mecanico mecanico1 = new Mecanico(5);
			Mecanico mecanico2 = new Mecanico(3);
			Mecanico mecanico3 = new Mecanico(26);
			Mecanico mecanico4 = new Mecanico(35);
			Mecanico mecanico5 = new Mecanico(10);
			Mecanico mecanico6 = new Mecanico(6);
			
			taller.agregarEmpleado(mecanico1);
			taller.agregarEmpleado(mecanico2);
			taller.agregarEmpleado(mecanico3);
			taller.agregarEmpleado(mecanico4);
			taller.agregarEmpleado(mecanico5);
			taller.agregarEmpleado(mecanico6);		
			
			StrategyMejorAPeor strategy = new StrategyMejorAPeor();
			taller.setStrategy(strategy);
			
			Cliente cliente1 = new Cliente();
			Cliente cliente2 = new Cliente();
			Cliente cliente3 = new Cliente();
			
			atender(taller, cliente1);
			atender(taller, cliente2);
			atender(taller, cliente3);
			
			Console.ReadKey(true);
		}
		
		public static void atender(INegocio taller, ICliente cliente)
		{
			taller.llegaCliente(cliente);
		}
	}
}