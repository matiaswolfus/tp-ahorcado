namespace TP_AHORCADO.Models;

public class juegoAhorcado
{
     public string palabra = "natalicio";

     public List <char> letrasUsadas = new List<char> ();

   
     public string palabraParcial = "_________" ;
     public int intentos = 0 ;




    public  bool matchLetra(char letra)
    {


        letrasUsadas.Add(letra);
        intentos++;
        bool coincide = false;
        foreach(char item in palabra)
        {
            if(letra == item) 
            {
               
                completarPalabraParcial(letra);
            }
        }
        if (palabra == palabraParcial)
        {
             coincide = true;
        }
        return coincide;
	}

    public  string completarPalabraParcial (char letra) 
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
    
    public  bool matchPalabra(string palabraIngresada)
    {
        bool arriesga = false;
        
            if(palabraIngresada == palabra) 
            {
                arriesga = true;
            }
       
        return arriesga;
	}

}






