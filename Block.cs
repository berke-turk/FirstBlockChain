using System;

namespace FirstBlockChain
{
    public class Block
    {
        private int index;
        public int getIndex(){
            return this.index;
        }
        private string previousHash;
        public string getPreviousHash(){
            return this.previousHash;
        }
        private string timestamp;
        public string getTimestamp(){
            return this.timestamp;
        }
        private string data;
        public string getData(){
            return this.data;
        }
        private string hash;
        
        public void setHash(string _hash)
        {
            this.hash = _hash;
        }
        
        public string getHash()
        {
            return this.hash;
        }
        private int nonce;
        public int getNonce(){
            return this.nonce;
        }

        public Block()
        {

        }
        public Block(int _index, string _previousHash, string _timestamp, string _data, int _nonce)
        {
            this.index = _index;
            this.previousHash = _previousHash;
            this.timestamp = _timestamp;
            this.data = _data;
            this.nonce = _nonce;
        }

        public Block(int _index, string _previousHash, string _timestamp, string _data, string _hash, int _nonce)
        {
            this.index = _index;
            this.previousHash = _previousHash;
            this.timestamp = _timestamp;
            this.data = _data;
            this.hash = _hash;
            this.nonce = _nonce;
        }

        public string viewBlock()
        {
            return $"index : {this.index} | previous hash : {this.previousHash} | timestamp : {this.timestamp} | data : {this.data} | hash : {this.hash} | nonce : {nonce}";
        }
    }

    public class GenesisBlock
    {
        public static Block getGenesisBlock()
        {
            return new Block(0, "0", DateTime.Now.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'"), "First Coinnnnnn in BlockChain", "000dc75a315c77a1f9c98fb6247d03dd18ac52632d7dc6a9920261d8109b37cf", 604);
        }
    }
}