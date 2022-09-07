namespace numMet_1;

public class Matrix {
    public double[] di;
    public int[] ia;
    public double[] al;
    public double[] au;
    public int Size {get; init;}

    public Matrix(string path){
        using (var sr = new StreamReader(path)){
            Size = int.Parse(sr.ReadLine());
            ia = sr.ReadLine().Split(" ")
                .Select(input => int.Parse(input)-1).ToArray();
            al = sr.ReadLine().Split(" ")
                .Select(input => double.Parse(input)).ToArray();
            au = sr.ReadLine().Split(" ")
                .Select(input => double.Parse(input)).ToArray();
            di = sr.ReadLine().Split(" ")
                .Select(input => double.Parse(input)).ToArray();
        }
    }
    
    public void PrintMatrix(){
        Console.Write("ia: ");
        Array.ForEach(ia, x => Console.Write(x + " "));
        Console.Write("\n");
        Console.Write("di: ");
        Array.ForEach(di, x => Console.Write(x + " "));
        Console.Write("\n");
        Console.Write("al: ");
        Array.ForEach(al, x => Console.Write(x + " "));
        Console.Write("\n");
        Console.Write("au: ");
        Array.ForEach(au, x => Console.Write(x + " "));
        Console.Write("\n");
    }
    

    public void LLt(){
       for (int i = 0; i < Size; i++){
           double sumdi = 0;

           int i0 = ia[i];
           int i1 = ia[i+1];
           
           int j = i - (i1 - i0);

           for (int ij = i0; ij < i1; ij++){
               double suml = 0.0;
               
                int j0 = ia[j];
                int j1 = ia[j0+1];

                int ik = i0;
                int jk = j0;
                
                int k = i - (i1 - i0);

                for ( ; ik < ij; ik++, jk++, k++){
                    suml += al[ik] * al[jk] * di[k];
                }

                al[ij] = (al[ij] - suml) / di[k];
                
                sumdi += al[ij] * al[ij];
           }
           di[i] = Math.Sqrt(di[i] - sumdi);
       } 
       Console.WriteLine("a");
    }
}