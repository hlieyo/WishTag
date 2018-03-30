using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishTag
{
    public class WishTagModel
    {
        /// <summary>
        /// wish 原词
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 翻译后的关键词
        /// </summary>
        public string ZhTagName { get; set; }
    }
}
