<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="ScrollingMarqee.VisualWebPart1.VisualWebPart1" %>
<%--<SharePoint:CssRegistration ID="CssRegistration1"  runat="server" Name="/Style Library/marquee.css" />--%>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
 <script type="text/javascript">
     function myfunction() {
         $(function () {
              var scroller = $('#scroller div.innerScrollArea');
             //var scroller = $('#litScrollingText div.innerScrollArea');
             var scrollerContent = scroller.children('ul');
             scrollerContent.children().clone().appendTo(scrollerContent);
             var curX = 0;
             scrollerContent.children().each(function () {
                 var $this = $(this);
                 $this.css('left', curX);
                 curX += $this.outerWidth(true);
             });
             var fullW = curX / 2;
             var viewportW = scroller.width();
             // Scrolling speed management
             var controller = { curSpeed: 0, fullSpeed: 2 };
             var $controller = $(controller);
             var tweenToNewSpeed = function (newSpeed, duration) {
                 if (duration === undefined)
                     duration = 600;
                 $controller.stop(true).animate({ curSpeed: newSpeed }, duration);
             };
             // Pause on hover
             scroller.hover(function () {
                 tweenToNewSpeed(0);
             }, function () {
                 tweenToNewSpeed(controller.fullSpeed);
             });
             // Scrolling management; start the automatical scrolling
             var doScroll = function () {
                 var curX = scroller.scrollLeft();
                 var newX = curX + controller.curSpeed;
                 if (newX > fullW * 2 - viewportW)
                     newX -= fullW;
                 scroller.scrollLeft(newX);
             };
             setInterval(doScroll, 40);
             tweenToNewSpeed(controller.fullSpeed);
         });
     }
 </script>
<style type="text/css">
    #scroller {
        position: relative; font-family:Verdana; background-color:#459ED3; border:1px solid lime;
    }
    #scroller .innerScrollArea {
        overflow: hidden;
        position: absolute;
        left: 0;
        right: 0;
        top: 0;
        bottom: 0;
        margin: 5px 5px 5px 5px;
        
    }
    #scroller ul {
        padding: 0;
        margin: 0;
        position: relative;
         margin: 5px 5px 5px 5px;
         
    }
   #scroller li {
        padding: 5px 5px 5px 5px;
        margin: 5px 5px 5px 5px;
        list-style-type: none;
        position: absolute;
        clear:left; text-align:center;border:3px inset black;
        width:150px;
        height:255px;
    }
    #scroller img { width:100px; height:100px;}

    #scroller p {text-align:left; font-family:Verdana; font-size:larger; width:140px; word-break:normal; margin-top:2px;}

    #scroller h5 {text-align:center;}
    h2 {text-align:center;}
    h3 {text-align: center;}

    </style>
<h2>Staff Recognition</h2>

<div id="scroller" style="width: 250px; height: 300px; margin: 0 auto; overflow:hidden; color:white; ">
    <div class="innerScrollArea" >
        <ul>
          <asp:Literal ID="litScrollingText" runat="server"></asp:Literal>
        </ul>
     </div>
</div>
<h3><a href="/Lists/Way%20To%20Go/AllItems.aspx">Show Full List </br> Recognize/add a co-worker</a></h3>