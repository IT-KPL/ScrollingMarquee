﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5477
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScrollingMarqee.VisualWebPart1 {
    using System.Web;
    using System.Text.RegularExpressions;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint.WebControls;
    using System.Web.Security;
    using Microsoft.SharePoint.Utilities;
    using System.Web.UI;
    using System;
    using System.Web.UI.WebControls;
    using System.Collections.Specialized;
    using Microsoft.SharePoint;
    using System.Collections;
    using System.Web.Profile;
    using System.Text;
    using System.Web.Caching;
    using System.Configuration;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.SessionState;
    using System.Web.UI.HtmlControls;
    
    
    public partial class VisualWebPart1 {
        
        protected global::System.Web.UI.WebControls.Literal litScrollingText;
        
        public static implicit operator global::System.Web.UI.TemplateControl(VisualWebPart1 target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private global::System.Web.UI.WebControls.Literal @__BuildControllitScrollingText() {
            global::System.Web.UI.WebControls.Literal @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.Literal();
            this.litScrollingText = @__ctrl;
            @__ctrl.ID = "litScrollingText";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::ScrollingMarqee.VisualWebPart1.VisualWebPart1 @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n\r\n<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jque" +
                        "ry/1.8.1/jquery.min.js\"></script>\r\n <script type=\"text/javascript\">\r\n     functi" +
                        "on myfunction() {\r\n         $(function () {\r\n              var scroller = $(\'#sc" +
                        "roller div.innerScrollArea\');\r\n             //var scroller = $(\'#litScrollingTex" +
                        "t div.innerScrollArea\');\r\n             var scrollerContent = scroller.children(\'" +
                        "ul\');\r\n             scrollerContent.children().clone().appendTo(scrollerContent)" +
                        ";\r\n             var curX = 0;\r\n             scrollerContent.children().each(func" +
                        "tion () {\r\n                 var $this = $(this);\r\n                 $this.css(\'le" +
                        "ft\', curX);\r\n                 curX += $this.outerWidth(true);\r\n             });\r" +
                        "\n             var fullW = curX / 2;\r\n             var viewportW = scroller.width" +
                        "();\r\n             // Scrolling speed management\r\n             var controller = {" +
                        " curSpeed: 0, fullSpeed: 2 };\r\n             var $controller = $(controller);\r\n  " +
                        "           var tweenToNewSpeed = function (newSpeed, duration) {\r\n              " +
                        "   if (duration === undefined)\r\n                     duration = 600;\r\n          " +
                        "       $controller.stop(true).animate({ curSpeed: newSpeed }, duration);\r\n      " +
                        "       };\r\n             // Pause on hover\r\n             scroller.hover(function " +
                        "() {\r\n                 tweenToNewSpeed(0);\r\n             }, function () {\r\n     " +
                        "            tweenToNewSpeed(controller.fullSpeed);\r\n             });\r\n          " +
                        "   // Scrolling management; start the automatical scrolling\r\n             var do" +
                        "Scroll = function () {\r\n                 var curX = scroller.scrollLeft();\r\n    " +
                        "             var newX = curX + controller.curSpeed;\r\n                 if (newX >" +
                        " fullW * 2 - viewportW)\r\n                     newX -= fullW;\r\n                 s" +
                        "croller.scrollLeft(newX);\r\n             };\r\n             setInterval(doScroll, 4" +
                        "0);\r\n             tweenToNewSpeed(controller.fullSpeed);\r\n         });\r\n     }\r\n" +
                        " </script>\r\n<style type=\"text/css\">\r\n    #scroller {\r\n        position: relative" +
                        "; font-family:Verdana; background-color:#459ED3; border:1px solid lime;\r\n    }\r\n" +
                        "    #scroller .innerScrollArea {\r\n        overflow: hidden;\r\n        position: a" +
                        "bsolute;\r\n        left: 0;\r\n        right: 0;\r\n        top: 0;\r\n        bottom: " +
                        "0;\r\n        margin: 5px 5px 5px 5px;\r\n        \r\n    }\r\n    #scroller ul {\r\n     " +
                        "   padding: 0;\r\n        margin: 0;\r\n        position: relative;\r\n         margin" +
                        ": 5px 5px 5px 5px;\r\n         \r\n    }\r\n   #scroller li {\r\n        padding: 5px 5p" +
                        "x 5px 5px;\r\n        margin: 5px 5px 5px 5px;\r\n        list-style-type: none;\r\n  " +
                        "      position: absolute;\r\n        clear:left; text-align:center;border:3px inse" +
                        "t black;\r\n        width:150px;\r\n        height:255px;\r\n    }\r\n    #scroller img " +
                        "{ width:100px; height:100px;}\r\n\r\n    #scroller p {text-align:left; font-family:V" +
                        "erdana; font-size:larger; width:140px; word-break:normal; margin-top:2px;}\r\n\r\n  " +
                        "  #scroller h5 {text-align:center;}\r\n    h2 {text-align:center;}\r\n    h3 {text-a" +
                        "lign: center;}\r\n\r\n    </style>\r\n<h2>Staff Recognition</h2>\r\n\r\n<div id=\"scroller\"" +
                        " style=\"width: 250px; height: 300px; margin: 0 auto; overflow:hidden; color:whit" +
                        "e; \">\r\n    <div class=\"innerScrollArea\" >\r\n        <ul>\r\n          "));
            global::System.Web.UI.WebControls.Literal @__ctrl1;
            @__ctrl1 = this.@__BuildControllitScrollingText();
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n        </ul>\r\n     </div>\r\n</div>\r\n<h3><a href=\"/Lists/Way%20To%20Go/AllItems." +
                        "aspx\">Show Full List </br> Recognize/add a co-worker</a></h3>"));
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}