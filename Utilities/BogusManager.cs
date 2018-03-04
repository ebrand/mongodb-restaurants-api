using Bogus;
using System;

namespace Utilities
{
    public class BogusManager
    {
        private static readonly BogusManager _instance = new BogusManager();
        static BogusManager(){}
        private BogusManager()
        {
            _faker = new Faker();
        }
        public static BogusManager Instance { get { return _instance; } }
        private Faker _faker;
        public Faker Faker { get { return _faker; } }
    }
}