<%@ Page Title="Reparacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reparacion.aspx.cs" Inherits="PcesRepair.Reparacion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h1 class="text-center mb-4">Gestión de Reparaciones</h1>
        <div class="row justify-content-center">
            <!-- Card 1: Crear nuevo formulario -->
            <div class="col-md-4">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <i class="bi bi-file-earmark-plus-fill display-4 text-primary"></i>
                        <h5 class="card-title mt-3">Nuevo Formulario</h5>
                        <p class="card-text">Crear un nuevo formulario de reparación para registrar una incidencia.</p>
                        <asp:Button ID="btnNuevoFormulario" runat="server" Text="Crear Formulario" CssClass="btn btn-primary" OnClick="btnNuevoFormulario_Click" />
                    </div>
                </div>
            </div>

            <!-- Card 2: Actualizar datos de reparación -->
            <div class="col-md-4">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <i class="bi bi-pencil-square display-4 text-success"></i>
                        <h5 class="card-title mt-3">Actualizar Datos</h5>
                        <p class="card-text">Actualizar los datos de reparación de una incidencia existente.</p>
                        <asp:Button ID="btnActualizarDatos" runat="server" Text="Actualizar Datos" CssClass="btn btn-success" OnClick="btnActualizarDatos_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

