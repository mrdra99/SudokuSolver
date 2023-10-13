using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace SudokuRisolutore
{
    public class SudokuLettoreScrittore
    {
        public string filePathReadGriglia = string.Empty;
        public string filePathWriteGriglia = string.Empty;
        public SudokuLettoreScrittore(string filePathReadWrite)
        {
            filePathReadGriglia = filePathReadWrite + "/SudokuNonRisolto.txt";
            filePathWriteGriglia = filePathReadWrite + "/SudokuRisolto.txt";
        }
        public int[,] ReadSudokuGridFromFileAndReturnMatrix()
        {
            try
            {
                string[] linee = File.ReadAllLines(filePathReadGriglia);
                int[,] sudokuGriglia = new int[9, 9];
                int riga = 0;

                for (int i = 0; i < 9; i++)
                {
                    string linea = linee[i];
                    string[] values =  linea.Split(' ');
                    int[] arrayDiInteri = new int[values.Length];

                    //CONVERTO IL VALORE DELLE STRINGHE NEL VETTORE DI INTERI
                    for (int u = 0; u < values.Length; u++)
                    {
                        arrayDiInteri[u] = int.Parse(values[u]);
                        sudokuGriglia[riga, u] = arrayDiInteri[u];
                    }
                    riga++;
                }

                return sudokuGriglia;
            }
            catch (IOException e)
            {
                Console.WriteLine("Errore nella lettura del file: " + e.Message);
                return null;
            }
        }
        public void StampaSudokuRisolto(int[,] grigliaSudoku)
        {
            string[] lineeSudokuRisolto = new string[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    lineeSudokuRisolto[i] += (grigliaSudoku[i, j].ToString() + " ");
                    File.WriteAllLines(filePathWriteGriglia, lineeSudokuRisolto);
                }
            }
        }
    }
}
