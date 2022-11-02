
namespace Labs_LIPO
{
    class Token
    {
        public TokenType _type { get; private set; }
        public string _text { get; private set; }
        public int _position { get; private set; }

        public Token(TokenType type, string text, int position)
        {
            _type = type;
            _text = text;
            _position = position;
        }

        public override string ToString()
        {
            return "type: { " + _type + " }, text: " + _text + ", position: " + _position;
        }
    }
}
