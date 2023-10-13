using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuRisolutore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pathGriglia = "C:/Users/Dragos/Desktop/PROGETTI/Sudoku/Griglie";
            SudokuLettoreScrittore lettore = new SudokuLettoreScrittore(pathGriglia);
            SudokuRisolutore risolutore = new SudokuRisolutore();

            var griglia = lettore.ReadSudokuGridFromFileAndReturnMatrix();
            risolutore.RisolviSudoku(griglia);
        }
    }
}
