using SiliconStudio.Core.Mathematics;
using SiliconStudio.Core.Serialization.Assets;
using SiliconStudio.Paradox.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineShip.Blocks
{
    public static class BlockDefinitions
    {
        private static Dictionary<string, string> _texturesPath;
        private static Dictionary<string, Texture> _textures;
    //    private static Dictionary<string, Color4> _colors;

        static BlockDefinitions()
        {
            _texturesPath = new Dictionary<string, string>();
            _texturesPath.Add("metal1", "Blocks/Textures/metal1_block");

            //_colors = new Dictionary<string, Color4>();
            _textures = new Dictionary<string, Texture>();
        }

        public static Texture getTextureById(string id, AssetManager assetManger)
        {
            if (!_texturesPath.ContainsKey(id))
            {
                throw new KeyNotFoundException("invalid id");
            }

            string path = _texturesPath[id];

            if (!_textures.ContainsKey(path))
            {
                _textures.Add(path, assetManger.Load<Texture2D>(path));
            }

            return _textures[path];
        }

       /* private static readonly Color4 DEFAULT_COLOR = Color4.White;

        public static Color4 getColorById(string id)
        {
            if (!_colors.ContainsKey(id))
                return DEFAULT_COLOR;

            return _colors[id];
        }*/
    }
}
