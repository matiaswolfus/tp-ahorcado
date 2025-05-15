namespace TP_AHORCADO.Models;

static public class ahorcado
{
    static public string palabra = "natalicio";

    static public List <char> letrasUsadas = new List<char> ();

   
    static public string palabraParcial = "_________" ;
    static public int intentos;




    public static bool matchLetra(char letra)
    {
        letrasUsadas.Add(letra);
        intentos++;
        bool coincide = false;
        foreach(char item in palabra)
        {
            if(letra == item) 
            {
                coincide = true;
                completarPalabraParcial(letra);
            }
        }
        return coincide;
	}

    public static string completarPalabraParcial (char letra) 
    {
        string auxiliar="";
        for(int i = 0; i < palabra.Count(); i++)
        {
            if (palabra[i] == letra)
            {
                auxiliar += letra;
            }
            else
            {
                auxiliar += palabraParcial[i];
            }   
        }
        palabraParcial = auxiliar;
        return palabraParcial;


    }
    
    public static bool matchPalabra(string palabraIngresada)
    {
        bool arriesga = false;
        
            if(palabraIngresada == palabra) 
            {
                arriesga = true;
            }
       
        return arriesga;
	}

}






