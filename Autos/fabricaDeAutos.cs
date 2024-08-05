using System;
using System.IO;
using System.Text.Json;
using caracteristicasAutos;
using DatosAuto;

public class Auto{
    public Datos Datos{get; set;}
    public Caracteristicas Caracteristicas{get; set;}
    public Auto(Datos datos, Caracteristicas caracteristicas){
        Datos = datos;
        Caracteristicas = caracteristicas;
    }
}
public class FabricaDeAutos{
    public Auto CrearAuto(Datos datos){
        var caracteristicas = new Caracteristicas();
        return new Auto(datos,caracteristicas);
    }

    public async Task<List<Auto>>CrearListaDeAutos(){
        Raiz listaConInfoAutos = await ObtenerDatosApi();
        if (listaConInfoAutos != null)
        {
            return ListaCreadaApi(listaConInfoAutos);
        }else
        {
            return ListaCreadaSinApi();
        }
    }
    
    public List<Auto> ListaCreadaApi(Raiz raiz){
        var listaAutos = new List<Auto>();
        foreach(var Auto in raiz.data.Resultados){
            if (Auto.Marca != string.Empty)
            {
                var AutoCreado = CrearAuto(new Datos(Auto.Marca, Auto.Modelo));
                listaAutos.Add(AutoCreado);
            }
        }
        return listaAutos;
    }

    public List<Auto> ListaCreadaSinApi(){
        var listaAutos = new List<Auto>();
        var manejoJson = new ManejoJson();
        string nombreArchivo = "modelosAutos.json";
        if (!File.Exists(nombreArchivo))
        {
            CrearArchivoDatosAutos(nombreArchivo);
        }
        string stringJson = manejoJson.AbrirArchivo(nombreArchivo);
        var listaDatos = JsonSerializer.Deserialize<List<Datos>>(stringJson);
        foreach(var datos in listaDatos){
            var nuevoAuto = CrearAuto(datos);
            listaAutos.Add(nuevoAuto);
        }
        return listaAutos;
    }
    public void CrearArchivoDatosAutos(string nombreArchivo){
        var listaDatos = new List<Datos>();
        var ManejoJson = new ManejoJson();
        listaDatos.Add(new Datos("Audi", "A4"));
        listaDatos.Add(new Datos("Toyota", "Corolla"));
        listaDatos.Add(new Datos("Mercedes Benz", " GT 4"));
        listaDatos.Add(new Datos("Peugeot", "408"));
        listaDatos.Add(new Datos("Fiat", "147"));
        listaDatos.Add(new Datos("Chevrolet", "Camaro"));

        string stringJson = JsonSerializer.Serialize(listaDatos);
        ManejoJson.GuardarArchivo(nombreArchivo,stringJson);
    }
}
