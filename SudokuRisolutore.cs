using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace SudokuRisolutore
{
    public class SudokuRisolutore
    {
        public SudokuLettoreScrittore sudokuReadWriter;
        string pathGriglia = string.Empty;
        public SudokuRisolutore()
        {
            pathGriglia = "C:/Users/Dragos/Desktop/PROGETTI/Sudoku/Griglie";
            sudokuReadWriter = new SudokuLettoreScrittore(pathGriglia);
        }
        public void RisolviSudoku(int[,] griglia)
        {
            var isRisolto = SolveSudoku(griglia);
        }
        public Boolean SolveSudoku(int[,] grigliaSudoku)
        {
            int riga = -1;
            int colonna = -1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grigliaSudoku[i, j] == 0)
                    {
                        riga = i;
                        colonna = j;
                        break;
                    }
                }
                if (riga != -1) break;
            }

            // Se non ci sono caselle vuote rimaste, hai risolto il Sudoku
            if (riga == -1 && colonna == -1)
            {
                sudokuReadWriter.StampaSudokuRisolto(grigliaSudoku);
                return true;
            }
            for (int num = 1; num <= 9; num++)
            {
                if (IsNumberValid(grigliaSudoku, riga, colonna, num))
                {
                    grigliaSudoku[riga, colonna] = num;

                    // Richiama ricorsivamente la funzione per la prossima casella
                    if (SolveSudoku(grigliaSudoku))
                    {
                        return true;
                    }
                    // Se la ricorsione non ha portato a una soluzione, reimposta la casella a 0
                    grigliaSudoku[riga, colonna] = 0;
                }
            }
            return false;
        }



        private bool IsNumberValid(int[,] grigliaSudoku, int riga, int colonna, int num)
        {
            bool isValid = true;
            for (int i = 0; i < 9; i++)
            {
                if(grigliaSudoku[riga, i] == num || grigliaSudoku[i,colonna] == num)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
