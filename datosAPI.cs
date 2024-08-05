using System.Text.Json.Serialization;
using System.Text.Json;

public class DatosRaiz{
    [JsonPropertyName("resultados")]
    public List<Resultados> Resultados {get; set;}
}

public class Resultados{
    [JsonPropertyName("marca")]
    public string Marca{get; set;}
    
    [JsonPropertyName("modelo")]
    public string Modelo{get; set;}
}

public class Raiz{
    public DatosRaiz data {get; set;}
}