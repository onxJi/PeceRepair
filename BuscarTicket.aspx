<%@ Page Language="C#" Title="Buscar Ticket" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarTicket.aspx.cs" Inherits="PcesRepair.BuscarTicket" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Buscar Ticket</h2>
        <div class="needs-validation" novalidate="true">
            <div class="row">
                <!-- Número de Ticket -->
                <div class="col-md-6 mb-3">
                    <label for="txtNumeroTicket" class="form-label">Número de Ticket:</label>
                    <asp:TextBox ID="txtNumeroTicket" runat="server" CssClass="form-control" />
                    
                    <!-- Validación requerida -->
                    <asp:RequiredFieldValidator 
                        ID="rfvNumeroTicket" 
                        runat="server" 
                        ControlToValidate="txtNumeroTicket"
                        ErrorMessage="El número de ticket es obligatorio." 
                        CssClass="text-danger" 
                        ValidationGroup="vgBuscarTicket" />
                    
                    <!-- Validación formato UUID -->
                    <asp:RegularExpressionValidator 
                        ID="revNumeroTicket" 
                        runat="server" 
                        ControlToValidate="txtNumeroTicket"
                        ErrorMessage="El número de ticket debe tener un formato UUID válido (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)." 
                        CssClass="text-danger"
                        ValidationExpression="^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$" 
                        ValidationGroup="vgBuscarTicket" />
                </div>
            </div>
        </div>
        <!-- Botón para buscar -->
        <div class="row">
            <div class="col-md-6 mb-3">
                <asp:Button 
                    ID="btnBuscar" 
                    runat="server" 
                    Text="Buscar" 
                    CssClass="btn btn-primary" 
                    ValidationGroup="vgBuscarTicket" 
                    OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
