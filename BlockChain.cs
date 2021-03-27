using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FirstBlockChain
{
    public class Blockchain
    {
        private static List<Block> blockchain = new List<Block>();
        private static int difficulty = 5; // Zorluk seviyesi
        private static bool isMining = false;
        public static void CreateGenesisBlock()
        {
            blockchain.Add(GenesisBlock.getGenesisBlock());
        }

        public static void StartMining()
        {
            isMining = true;
            int nonce;
            while (isMining)
            {
                nonce = 1;
                while (true)
                {
                    Block block = new Block(Blockchain.latestIndex() + 1, Blockchain.getLatestBlock().getHash(), DateTime.Now.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'"), "Jsscoin", nonce);

                    block.setHash(Blockchain.calculateHashForBlock(block));

                    if (Blockchain.addBlock(block))
                    {
                        // Eklenmişse
                        break;
                    }
                    else
                    {
                        // Eklenmemişse
                        nonce++;
                    }
                }
            }
        }

        public static void StopMining()
        {
            isMining = false;
        }

        public static List<Block> getBlockChain()
        {
            return blockchain;
        }
        public static int latestIndex()
        {
            return blockchain.Count - 1;
        }
        public static Block getLatestBlock()
        {
            return blockchain[blockchain.Count - 1];
        }

        public static bool addBlock(Block block)
        {
            if (isValidHashDifficulty(block.getHash()))
            {
                // True
                Console.WriteLine($" {block.viewBlock()}  \n is Valid : true");
                blockchain.Add(block);
                return true;
            }
            else
            {
                //Console.WriteLine($" {block.viewBlock()}  \n is Valid : false");
                return false;
            }
        }

        public static string calculateHashForBlock(Block block)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes($"{block.getIndex()}-{block.getPreviousHash()}-{block.getTimestamp()}-{block.getData()}-{block.getNonce()}"));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static bool isValidHashDifficulty(string hash) // Burası tamaen kendi kabul sistemimiz. Bir hash i kabul etmek için hash üzerinde farklı kontroller yapabilirsiniz.
        {
            int sayac = 0;
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != '0')
                {
                    sayac = i;
                    break;
                }
            }
            return sayac >= difficulty;
        }
    }
}
