using numMet_1;

Matrix matrix = new Matrix("TestMatrix");
Vector vector = new Vector(matrix.Size);
SLAE Solution = new SLAE(matrix, vector);
Solution.LDU();
matrix.PrintMatrix();