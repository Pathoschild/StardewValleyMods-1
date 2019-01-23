﻿using TehPers.CoreMod.Api.ContentPacks;
using TehPers.CoreMod.Api.ContentPacks.Tokens;

namespace TehPers.CoreMod.ContentPacks.Tokens.Parsing {
    internal class TokenTokenizedStringPart : ITokenizedStringPart {
        private readonly IToken _token;
        private readonly string[] _arguments;

        public TokenTokenizedStringPart(IToken token, string[] arguments) {
            this._token = token;
            this._arguments = arguments;
        }

        public bool IsValidInContext(IContext context) {
            return this._token.IsValidInContext(context);
        }

        public TokenValue GetValue(ITokenHelper helper) {
            return this._token.GetValue(helper, this._arguments);
        }
    }
}