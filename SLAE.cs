namespace numMet_1;


public class SLAE{
    public Matrix matrix;
    public Vector vector;
    public Vector? solution;
    
    public SLAE(Matrix Matrix, Vector Vector){
        matrix = Matrix;
        vector = Vector;
        solution = new Vector(Matrix.Size);
    }

    public void LDU() {
        for (int i = 0; i < matrix.Size; i++){
            double sumdi = 0;

            int i0 = matrix.ia[i];
            int i1 = matrix.ia[i+1];

            int j = i - (i1 - i0);

            for (int ij = i0; ij < i1; ij++, j++){
                double suml = 0.0;
                double sumu = 0.0;

                int j0 = matrix.ia[j];
                int j1 = matrix.ia[j+1];
                
                int ik = i0;
                int jk = j0;

                int k = i - (i1 - i0);

                int ci = ij - i0; // длина строки до ij элемента
                int cj = j1 - j0; // длина столбца
                
                int cij = ci - cj;

                if (cij > 0){
                    ik += cij;
                    k += cij; 
                } else {
                    jk -= cij;
                }
                
                for ( ; ik < ij; ik++, jk++, k++){
                    suml += matrix.al[ik] * matrix.au[jk] * matrix.di[k];
                    sumu += matrix.au[ik] * matrix.al[jk] * matrix.di[k];
                }

                matrix.al[ij] = (matrix.al[ij] - suml) / matrix.di[j];
                matrix.au[ij] = (matrix.au[ij] - sumu) / matrix.di[j];

                sumdi += matrix.al[ij] * matrix.au[ij] * matrix.di[k]; 
            }
            matrix.di[i] -= sumdi;
        }
    }
}