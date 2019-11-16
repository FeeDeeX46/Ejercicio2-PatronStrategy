/*
 * 
 * Clases e interfaces comunes para la evaluación de la materia Metodologías de Programación I.
 * 
 * Este archivo NO debe ser modificado para resolver el examen.
 * 
 */
 
using System;
using System.Collections.Generic;

namespace PrimeraFecha
{
	public interface ICliente {
		IMascota getMascota();
		ICabeza getCabeza();
		IAuto getAuto();
		void setMascota(IMascota mascota);
		void setAuto(IAuto auto);
		void cobrar(double precio);
		void setReaccion(IReaccion reaccion);
	}
	
	public interface IReaccion{
		void cobrar(double precio);
	}
	
	public class Cliente : ICliente{
		private IAuto auto = new Auto();
		private IMascota mascota = new Perro();
		private IReaccion reaccion = null;
		
		public IMascota getMascota(){
			return mascota;
		}
		
		public ICabeza getCabeza(){
			return new Cabeza();
		}
		
		public IAuto getAuto(){
			return auto;
		}
		
		public void setMascota(IMascota mascota){
			this.mascota = mascota;
		}
		
		public void setAuto(IAuto auto){
			this.auto = auto;
		}
		
		public void cobrar(double precio){
			if(reaccion != null)
				reaccion.cobrar(precio);
		}
		
		public void setReaccion(IReaccion reaccion){
			this.reaccion = reaccion;
		}
	}
	
	public interface IMascota {
		void revisar();
		void curar();
	}
	
	public class Perro : IMascota {
		public void revisar(){
			Console.WriteLine("Guau guau");
		}
		public void curar(){
			Console.WriteLine("Guau guau");
		}
	}
	
	public class Gato : IMascota {
		public void revisar(){
			Console.WriteLine("Miau miau");
		}
		public void curar(){
			Console.WriteLine("Miau miau");
		}
	}
	
	public class Vaca : IMascota {
		public void revisar(){
			Console.WriteLine("Muu muu");
		}
		public void curar(){
			Console.WriteLine("Muu muu");
		}
	}
	
	public class Chancho : IMascota {
		public void revisar(){
			Console.WriteLine("Oink oink");
		}
		public void curar(){
			Console.WriteLine("Oink oink");
		}
	}
	
	public interface ICabeza {
		void cortar(int experiencia);
		void peinar();
	}
	
	public class Cabeza : ICabeza {
		public void cortar(int experiencia){
			Console.WriteLine("Un peluquero con experiencia " + experiencia + " me está dejando sin pelos!!!");
		}
		public void peinar(){
			Console.WriteLine("Los pocos pelos que me quedaron al menos están prolijitos");
		}
	}
	
	public interface IAuto{
		void revisar();
		void arreglar(int experiencia);
	}
	
	public class Auto : IAuto{
		public void revisar(){
			Console.WriteLine("Parece que falta una pieza");
		}
		public void arreglar(int experiencia){
			Console.WriteLine("La pieza que faltaba ya está colocada por un mecánico de experiencia " + experiencia);
		}
	}
	
	public class Car {
		public void review(){
			Console.WriteLine("It seems that a piece is missing");
		}
		
		public void repair(int experience){
			Console.WriteLine("An mechanic with experience " + experience + " put the piece in place");
		}
	}
	
	public interface IEmpleado {
		void atender(ICliente cliente);
		int getExperiencia();
	}
	
	public interface INegocio {
		void llegaCliente(ICliente cliente);
		void agregarEmpleado(IEmpleado empleado);
	}
	
	public abstract class Negocio : INegocio {
		protected List<IEmpleado> empleados = new List<IEmpleado>();
		
		public void agregarEmpleado(IEmpleado empleado){
			empleados.Add(empleado);
		}
		
		protected virtual IEmpleado algunEmpleado(){
			IEmpleado empleado = empleados[0];
			empleados.RemoveAt(0);
			return empleado;
		}
		
		public virtual void llegaCliente(ICliente cliente){
			this.algunEmpleado().atender(cliente);
		}
	}
	
	public class Veterinaria : Negocio {
		public override void llegaCliente(ICliente cliente){
			base.llegaCliente(cliente);
			Console.WriteLine("Desparasitando el lugar");
		}
	}
	
	public class Peluqueria : Negocio {
		public override void llegaCliente(ICliente cliente){
			base.llegaCliente(cliente);
			Console.WriteLine("Barriendo el piso");
		}
	}
	
	public class TallerMecanico : Negocio {
		public override void llegaCliente(ICliente cliente){
			base.llegaCliente(cliente);
			Console.WriteLine("Lavando la mancha de aceite");
		}
	}
	
	public abstract class Empleado : IEmpleado{
		private int experiencia;
		private Random random = new Random();
		
		public Empleado (int experiencia){
			this.experiencia = experiencia;
		}
		
		public int getExperiencia(){
			return experiencia;
		}
		
		protected double costo(){
			return random.NextDouble() * 100 + 20;
		}
		
		public abstract void atender(ICliente cliente);
	}
	
	public class Veterinario : Empleado {
		public Veterinario (int experiencia) : base(experiencia) {			
		}
		
		public override void atender(ICliente cliente){
			IMascota mascota = cliente.getMascota();
			mascota.revisar();
			mascota.curar();
			cliente.cobrar(this.costo());
		}
	}
	
	public class Peluquero : Empleado {
		public Peluquero (int experiencia) : base(experiencia) {			
		}
		
		public override  void atender(ICliente cliente){
			ICabeza cabeza = cliente.getCabeza();
			cabeza.cortar(this.getExperiencia());
			cabeza.peinar();
			cliente.cobrar(this.costo());
		}
	}
	
	public class Mecanico : Empleado {
		public Mecanico (int experiencia) : base(experiencia) {			
		}
		
		public override  void atender(ICliente cliente){
			IAuto auto = cliente.getAuto();
			auto.revisar();
			auto.arreglar(this.getExperiencia());
			cliente.cobrar(this.costo());
		}
	}
}