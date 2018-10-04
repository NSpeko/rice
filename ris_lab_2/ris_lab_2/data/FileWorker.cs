using System;
using System.Collections;
using System.IO;
using ris_lab_2.model.candy;

namespace ris_lab_2.data
{
    public class FileWorker
    {
        private static FileWorker _fileWorker;
        private static FileStream _fileStream;
        private static StreamReader _streamReader;
        private static StreamWriter _streamWriter;
        private static char _delimeter;
        
        private FileWorker(){}

        public static FileWorker GetInstance(string path, char delimeter)
        {
            if (_fileWorker == null)
            {
                _fileWorker = new FileWorker();
                _fileStream = new FileStream(path,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                _streamReader = new StreamReader(_fileStream);
                _streamWriter = new StreamWriter(_fileStream);
                _delimeter = delimeter;
            }

            return _fileWorker;
        }
        
        public static FileWorker GetInstance()
        {
            if (_fileWorker == null)
            {
                _fileWorker = new FileWorker();
                _fileStream = new FileStream("d:\\file.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
                _streamReader = new StreamReader(_fileStream);
                _streamWriter = new StreamWriter(_fileStream);
                _delimeter = '|';
            }

            return _fileWorker;
        }
        
        public ArrayList GetCandiesFromFile()
        {
            ArrayList retrieveData = new ArrayList();
            while (!_streamReader.EndOfStream)
            {
                string line = _streamReader.ReadLine();
                if (line == null) {continue;}
                string []parameters = line.Split(_delimeter);
                CandySupply candy = new CandySupply();
                candy.supplyFrom = parameters[0];
                candy.supplyWho = parameters[1];
                candy.supplyWhat = parameters[2];
                candy.supplyAmount = Convert.ToInt64(parameters[3]);
                candy.supplyPrice = Convert.ToInt64(parameters[4]);
            }
            return retrieveData;
        }

        public void WriteCandyToFile(CandySupply candy)
        {
            _fileStream.Seek(0, SeekOrigin.End);
            _streamWriter.WriteLine(candy.supplyFrom + "*" + candy.supplyWho + "*" + candy.supplyWhat + "*" 
                                    + candy.supplyAmount.ToString() + "*"
                                    + candy.supplyPrice.ToString());
        }
    }
}