using System;

namespace FirstBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain.CreateGenesisBlock();
            // İlk uygulama için genesis block lazım.
            
            Blockchain.StartMining();
        }
    }
}
