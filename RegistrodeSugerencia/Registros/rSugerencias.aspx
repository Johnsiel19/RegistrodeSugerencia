<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rSugerencias.aspx.cs" Inherits="RegistrodeSugerencia.Registros.rSugerencias" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="panel" style="background-color: #ff7101">
        <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align:center; color: Black">Registro de Pacientes</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
              <div class="form-group">
                <label for="SugerenciaIdTextBox" class="col-md-3 control-label input-sm" style="font-size: small">SugerenciaId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="SugerenciaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="SugerenciaIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click"  />
                </div>
            </div>

               <%--Fecha--%>
                <div class="form-group">
             <label for="FechaTebox" class="col-md-3 control-label input-sm" style="font-size: small">Fecha</label>
               <div class="col-md-3">
                     <asp:TextBox ID="FechaTextBox" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RFVFecha" runat="server" MaxLength="200" ControlToValidate="FechaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
               </div>
                </div>


                            <%-- Nombres--%>
            <div class="form-group">
                <label for="DescripcionTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >Descripcion</label>
                <div class="col-md-6">
                    <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="DescripcionTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Descripcion es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
   

            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="NuevoButton_Click"   />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="GuardarButton_Click"/>
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
            </div>
    </div>
</asp:Content>
