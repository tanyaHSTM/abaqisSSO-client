<%@ Page Async="True" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p>
            <a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a>
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Abaqis Login</h2>
            <p>
                An example of implementing Abaqis Single Sign On using ASP.NET MVC
            </p>

            <span id="Message" runat="server"/>


            <input type="button" id="LoginButton" onclick="LoginToAbaqis()" value="Login To Abaqis"/>

            <script type="text/javascript">
                function LoginToAbaqis() {
                    "use strict";

                    var form = document.createElement("form");
                    form.method = "post";
                    form.action = 'https://test.abaqis.com/sso/token_login';
                    var tokenInput = document.createElement("hidden");
                    tokenInput.setAttribute("name", "login_token");
                    tokenInput.setAttribute("value", "<%= Token %>");
                    form.appendChild(tokenInput);

                    var sessionEndInput = document.createElement("hidden");
                    sessionEndInput.setAttribute("name", "onsessionend");
                    sessionEndInput.setAttribute("value", "<%= SessionEnd %>");
                    form.appendChild(sessionEndInput);
                    document.body.appendChild(form);
                    form.submit();
                }
            </script>
        </div>
    </div>

</asp:Content>