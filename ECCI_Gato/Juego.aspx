<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="ECCI_Gato.Juego" Async="true"  EnableEventValidation="false"%>
<%@ Import Namespace="System.Data" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="/js/jquery.min.js"></script>
    <script src="/js/skel.min.js"></script>
    <script src="/js/skel-layers.min.js"></script>
    <script src="/js/init.js"></script>
    <script src="/js/smoothscroll.min.js"></script>
    <style type="text/css">
        <!--
        table.tic td {
	        border: 1px solid #333 !important;
	        width: 51px;
	        height: 51px;
	        vertical-align: middle;
	        text-align: center;
	        font-size: 25pt;
	        font-family: Arial;
        }
        table { margin-bottom: 10px; }
        input.field {
	        border: 0;
	        background-color: #fff;
	        color: #fff !important;
	        height: 45px !important;
	        width: 45px !important;
	        font-family: Arial;
	        font-size: 25pt;
	        font-weight: normal;
	        cursor: pointer;
        }
        input.field:hover {
	        border: 0;
	        color: #900 !important;
        }
        -->
    </style>
    <title>Gato</title>



    <header>
        <h1>Gato</h1>
        <p>Juego de Gato online</p>
    </header>


    <h2>Bievenid@</h2>
     De inicio a la partida 
    <br />
    <br />


    <asp:Button runat="server" ID="Button9" Text="Iniciar Nuevo Juego" CssClass="btn btn-success" OnClick="NuevoJuego" CausesValidation="false" />
    <br />
    <br />
    <table class="tic" style="border-collapse: collapse">
        <tr>
            <td><asp:Button runat="server" ID="Button0" Text="" CssClass="btn btn-link" OnClick="btn0_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button1" Text="" CssClass="btn btn-link" OnClick="btn1_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button2" Text="" CssClass="btn btn-link" OnClick="btn2_Click" CausesValidation="false" /></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="Button3" Text="" CssClass="btn btn-link" OnClick="btn3_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button4" Text="" CssClass="btn btn-link" OnClick="btn4_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button5" Text="" CssClass="btn btn-link" OnClick="btn5_Click" CausesValidation="false" /></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="Button6" Text="" CssClass="btn btn-link" OnClick="btn6_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button7" Text="" CssClass="btn btn-link" OnClick="btn7_Click" CausesValidation="false" /></td>
            <td><asp:Button runat="server" ID="Button8" Text="" CssClass="btn btn-link" OnClick="btn8_Click" CausesValidation="false" /></td>
        </tr>
    </table>

    <div runat="server" id="infoGanador" visible="false">
        <br />
        <h2>Felicidades!</h2>
        Ganador, por favor ingrese su nombre.
        <input runat="server" type="text" class="form-control" id="inputNombre" placeholder="Nombre">
        <br />
        <asp:Button runat="server" ID="Button11" Text="Guardar" CssClass="btn btn-primary" OnClick="guardarGanador" CausesValidation="false" />
    </div>



    <div runat="server" id="top10" visible="false">
        <br />
        <h2>Top 10 de Jugadores</h2>
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th class="col-md-1">#</th>
                    <th class="col-md-1">Nombre</th>
                    <th class="col-md-1">Tiempo</th>
                </tr>
            </thead>
            <tbody>
            <%int i = 1; %>
            <%if (tabla.Tables.Count != 0)
                { %>
            <% foreach (DataRow row in tabla.Tables[0].Rows)
                                              { %>
                <tr>
                    <td><%= i %></td>
                    <td><%= row["Nombre"] %></td>
                    <td><%= row["Tiempo"] %></td>
                </tr>
                <%i++; %>
            <% }
            }%>
            </tbody>
        </table>
    </div>

    <h2>Cómo jugar</h2>
    Seleccione una celda con su mouse para poner su marca.
    <br />Si no conoce bien las reglas, puede verlas para mayor información en <a href="http://en.wikipedia.org/wiki/Tic-tac-toe" class="external"> Wikipedia</a>.
</asp:Content>