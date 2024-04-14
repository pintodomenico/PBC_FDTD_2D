using System.IO;

namespace PBC_FDTD_2D.Utilities;

public static class SaveFile
{

    public static void Save(double[] arrayToSave, string fileName)
    {
        using (StreamWriter sr = new StreamWriter(fileName))
        {
            foreach (var item in arrayToSave)
            {
                sr.WriteLine(item);
            }
        }

    }

    public static void Save(double[,] twoDimArrayToSave, int xDimension, int yDimension, string fileName)
    {
        using (StreamWriter sr = new StreamWriter(fileName))
        {
            for (int i = 0; i < xDimension; i++)
            {
                var arrayToSave = new double[yDimension];
                for (int j = 0; j < yDimension; j++)
                {
                    arrayToSave[j] = twoDimArrayToSave[i, j];
                }

                foreach (var item in arrayToSave)
                {
                    sr.Write(item);
                    sr.Write(" ");
                }
                sr.WriteLine();
            }
        }
    }


    //public static void Save(double[,] arrayToSave)
    //{
    //    //string[] table = { "1 a b c d", "2 q r t j", "3 w j s r" };
    //    string[] table = new string[5];
    //    for (int i = 0; i < 5; i++)
    //    {
    //        string line = arrayToSave[i, 0].ToString();
    //        for (int j = 1; j < 5; j++)
    //        {
    //            line = line + " " + arrayToSave[i, j].ToString();
    //        }
    //        table[i] = line;
    //    }

    //    System.IO.File.WriteAllLines(@"c:\data\test.dat", table);

    //    StreamReader reader = new StreamReader(@"c:\data\test.dat", System.Text.Encoding.Default);
    //    string[] values = reader.ReadToEnd().Split('\n');
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Console.WriteLine(values[i]);
    //    }
    //}


    //public static void Save(double[] arrayToSave, int dimension, string fileName)
    //{
    ////string[] table = { "1 a b c d", "2 q r t j", "3 w j s r" };
    //string[] table = new string[1];
    //for (int i = 0; i < 1; i++)
    //{
    //    string line = arrayToSave[0].ToString();
    //    for (int j = 1; j < dimension; j++)
    //    {
    //        line = line + " " + arrayToSave[j].ToString();
    //    }
    //    table[i] = line;
    //}

    //System.IO.File.WriteAllLines(fileName, table);

    //StreamReader reader = new StreamReader(@"c:\data\test.dat", System.Text.Encoding.Default);
    //string[] values = reader.ReadToEnd().Split('\n');
    //for (int i = 0; i < 5; i++)
    //{
    //    Console.WriteLine(values[i]);
    //}

    //using (BinaryWriter binWriter = new BinaryWriter(new FileStream(fileName,FileMode.Create)))
    //{
    //    // Write the data to the stream.
    //    Console.WriteLine("Writing data to the stream.");
    //    for (int i = 0; i < dimension; i++)
    //    {
    //        binWriter.Write(arrayToSave[i]);
    //    }

    //    // Create a reader using the stream from the writer.
    //    using (BinaryReader binReader = new BinaryReader(binWriter.BaseStream))
    //    {
    //        try
    //        {
    //            // Return to the beginning of the stream.
    //            binReader.BaseStream.Position = 0;

    //            // Read and verify the data.
    //            Console.WriteLine("Verifying the written data.");
    //            for (int i = 0; i < dimension; i++)
    //            {
    //                if (binReader.ReadDouble() != arrayToSave[i])
    //                {
    //                    Console.WriteLine("Error writing data.");
    //                    break;
    //                }
    //            }
    //            Console.WriteLine("The data was written " + "and verified.");
    //        }
    //        catch (EndOfStreamException e)
    //        {
    //            Console.WriteLine("Error writing data: {0}.",
    //                e.GetType().Name);
    //        }
    //    }
    //}
    //}
}
