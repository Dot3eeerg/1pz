namespace numMet_1;

public class Vector{
    public double[] vec;
    public int Size;

    public Vector(int size){
        Size = size;
        vec = new double[size];
    } 

    public void PrintVector(){
        Console.Write(nameof(vec) + ": ");
        Array.ForEach(vec, x => Console.Write(x + " "));
        Console.Write("\n");
    }

    public void ReadVector(string path){
        using (var sr = new StreamReader(path)){
            vec = sr.ReadLine().Split(" ").
                Select(input => double.Parse(input)).ToArray();
        }
    }
}