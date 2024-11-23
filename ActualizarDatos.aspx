<%@ Page Language="C#" Title="Actualizar Ticket" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarDatos.aspx.cs" Inherits="PcesRepair.ActualizarDatos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Actualizar Ticket</h2>
    <asp:ValidationSummary ID="vsErroresActualizar" runat="server" HeaderText="Errores encontrados:" 
        DisplayMode="BulletList" ValidationGroup="vgActualizarTicket" />

    <div class="row">
        <!-- Datos del Cliente -->
        <div class="col-md-6">
            <h3>Datos del Cliente</h3>
            <div class="form-group">
                <label for="txtTelefono">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvTelefonoActualizar" runat="server" ControlToValidate="txtTelefono"
                    ErrorMessage="El número telefónico es obligatorio." Display="Dynamic" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvEmailActualizar" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="El email es obligatorio." Display="Dynamic" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
                <asp:RegularExpressionValidator ID="revEmailActualizar" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Formato de email inválido. Ejemplo: usuario@dominio.com" Display="Dynamic"
                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
            </div>
        </div>

        <!-- Datos del Ticket -->
        <div class="col-md-6">
            <h3>Datos del Ticket</h3>
            <div class="form-group">
                <label for="txtProducto">Nombre del Producto:</label>
                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvProductoActualizar" runat="server" ControlToValidate="txtProducto"
                    ErrorMessage="El nombre del producto es obligatorio." Display="Dynamic" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
                <asp:RegularExpressionValidator ID="revProductoActualizar" runat="server" ControlToValidate="txtProducto"
                    ErrorMessage="El nombre del producto debe tener al menos 10 caracteres." Display="Dynamic"
                    ValidationExpression=".{10,}" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
            </div>
            <div class="form-group">
                <label for="txtDescripcion">Descripción del Producto:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDescripcionActualizar" runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción del producto es obligatoria." Display="Dynamic" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
                <asp:RegularExpressionValidator ID="revDescripcionActualizar" runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción debe tener al menos 10 caracteres." Display="Dynamic"
                    ValidationExpression=".{10,}" CssClass="text-danger"
                    ValidationGroup="vgActualizarTicket" />
            </div>
        </div>
    </div>

    <!-- Botón para actualizar -->
    <div class="form-group">
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Ticket" CssClass="btn btn-primary"
            OnClick="btnActualizar_Click" ValidationGroup="vgActualizarTicket" />
    </div>
</asp:Content>
