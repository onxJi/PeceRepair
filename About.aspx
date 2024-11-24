<%@ Page Title="Reparacion-Crear" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PcesRepair.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container mt-4">
    <!-- Datos del Cliente -->
    <h2>Datos del Cliente</h2>
    <div class="needs-validation" novalidate="true">
        <div class="row">
            <!-- Nombre -->
            <div class="col-md-6 mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El nombre debe tener al menos 5 caracteres." CssClass="text-danger"
                    ValidationExpression=".{5,}" ValidationGroup="vgCrearTicket" />
            </div>

            <!-- RUT -->
            <div class="col-md-6 mb-3">
                <label for="txtRut" class="form-label">RUT:</label>
                <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvRut" runat="server" ControlToValidate="txtRut"
                    ErrorMessage="El RUT es obligatorio." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
                <asp:RegularExpressionValidator ID="revRut" runat="server" ControlToValidate="txtRut"
                    ErrorMessage="Formato de RUT inválido. Ejemplo: 12345678-9" CssClass="text-danger"
                    ValidationExpression="^(\d{8,9}-[\dkK])$" ValidationGroup="vgCrearTicket" />
            </div>
        </div>

        <div class="row">
            <!-- Teléfono -->
            <div class="col-md-6 mb-3">
                <label for="txtTelefono" class="form-label">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                    ErrorMessage="El número telefónico es obligatorio." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
            </div>

            <!-- Email -->
            <div class="col-md-6 mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="El email es obligatorio." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Formato de email inválido. Ejemplo: usuario@dominio.com" CssClass="text-danger"
                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="vgCrearTicket" />
            </div>
        </div>

        <div class="row">
            <!-- Tipo de Cliente -->
            <div class="col-md-6 mb-3">
                <label for="ddlTipoCliente" class="form-label">Tipo de Cliente:</label>
                <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccionar" Value="" />
                    <asp:ListItem Text="Persona Natural" Value="PersonaNatural" />
                    <asp:ListItem Text="Empresa" Value="Empresa" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoCliente" runat="server" ControlToValidate="ddlTipoCliente"
                    InitialValue="" ErrorMessage="Debe seleccionar un tipo de cliente." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
            </div>
        </div>

        <!-- Datos del Ticket -->
        <h2 class="mt-4">Datos del Ticket</h2>
        <div class="row">
            <!-- Nombre del Producto -->
            <div class="col-md-6 mb-3">
                <label for="txtProducto" class="form-label">Nombre del Producto:</label>
                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                    ErrorMessage="El nombre del producto es obligatorio." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
                <asp:RegularExpressionValidator ID="revProducto" runat="server" ControlToValidate="txtProducto"
                    ErrorMessage="El nombre del producto debe tener al menos 10 caracteres." CssClass="text-danger"
                    ValidationExpression=".{10,}" ValidationGroup="vgCrearTicket" />
            </div>

            <!-- Descripción del Producto -->
            <div class="col-md-6 mb-3">
                <label for="txtDescripcion" class="form-label">Descripción del Producto:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción del producto es obligatoria." CssClass="text-danger" ValidationGroup="vgCrearTicket" />
                <asp:RegularExpressionValidator ID="revDescripcion" runat="server" ControlToValidate="txtDescripcion"
                    ErrorMessage="La descripción debe tener al menos 10 caracteres." CssClass="text-danger"
                    ValidationExpression=".{10,}" ValidationGroup="vgCrearTicket" />
            </div>
        </div>

        <!-- Botón de Crear -->
        <div class="text-end mt-3">
            <asp:Button ID="btnCrear" runat="server" Text="Crear Ticket" CssClass="btn btn-primary"
                ValidationGroup="vgCrearTicket"  OnClick="btnCrear_Click"/>
        </div>
        <div class="text-end mt-3">
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-success mt-3" />
        </div>
        <!-- Resumen de Validación -->
        <asp:ValidationSummary ID="vsErrores" runat="server" HeaderText="Errores:"
            DisplayMode="BulletList" ValidationGroup="vgCrearTicket" CssClass="text-danger mt-3" />
    </div>
</div>

</asp:Content>
