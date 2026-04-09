<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="examen_._Default" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <main class="fade-in-up">
            <section class="hero-section">
                <% if (Session["Rol"] !=null && Session["Rol"].ToString()=="Admin" ) { %>
                    <h1 class="hero-title">Gestion de Ventas</h1>
                    <p class="hero-subtitle">Optimiza tu negocio con nuestra plataforma premium de administracion de
                        productos, clientes y ventas en tiempo real.</p>
                    <% } else if (Session["Rol"] !=null && Session["Rol"].ToString()=="Cliente" ) { %>
                        <h1 class="hero-title">Bienvenido a nuestra Tienda</h1>
                        <p class="hero-subtitle">Explora nuestro catalogo de productos premium y realiza tus compras de
                            forma segura y rapida.</p>
                        <% } else { %>
                            <h1 class="hero-title">Tienda Premium</h1>
                            <p class="hero-subtitle">Inicia sesion para acceder a nuestras ofertas exclusivas y
                                gestionar tus pedidos.</p>
                            <% } %>
            </section>

            <div class="container mb-5">
                <div class="nav-card-container">
                    <% if (Session["Rol"] !=null && Session["Rol"].ToString()=="Admin" ) { %>
                        <a href="Productos.aspx" class="nav-card">
                            <i class="fas fa-box-open icon-blue"></i>
                            <h3>Productos</h3>
                            <p>Gestiona tu catalogo, controla el stock y actualiza precios con un solo clic.</p>
                        </a>

                        <a href="Clientes.aspx" class="nav-card">
                            <i class="fas fa-users icon-green"></i>
                            <h3>Clientes</h3>
                            <p>Manten un registro detallado de tus compradores y su informacion de contacto.</p>
                        </a>
                        <% } %>

                            <% if (Session["Rol"] !=null) { %>
                                <a href="Ventas.aspx" class="nav-card">
                                    <i class="fas fa-shopping-cart icon-purple"></i>
                                    <h3>Ventas</h3>
                                    <p>Registra nuevas transacciones con calculo automatico de totales y gestion de
                                        stock.</p>
                                </a>
                                <% } %>

                                    <% if (Session["Rol"] !=null && Session["Rol"].ToString()=="Admin" ) { %>
                                        <a href="HistorialVentas.aspx" class="nav-card">
                                            <i class="fas fa-history icon-blue"></i>
                                            <h3>Historial</h3>
                                            <p>Consulta el registro historico de todas las ventas realizadas en el
                                                sistema.</p>
                                        </a>
                                        <% } %>

                                            <% if (Session["Rol"]==null) { %>
                                                <div class="nav-card"
                                                    style="grid-column: 1 / -1; max-width: 600px; margin: 0 auto; text-align: center; cursor: default;">
                                                    <i class="fas fa-lock"
                                                        style="color: #00d2ff; font-size: 3rem; margin-bottom: 1rem;"></i>
                                                    <h3>Autenticacion Requerida</h3>
                                                    <p>Por favor, haz clic en el boton "Iniciar Sesion" en la esquina
                                                        superior derecha para entrar al sistema.</p>
                                                </div>
                                                <% } %>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-12 text-center">
                    <div class="glass-card" style="display:inline-block; padding: 1.5rem 3rem;">
                        <p style="margin:0; color:#b0b0b0;">
                            <% if (Session["Rol"] !=null && Session["Rol"].ToString()=="Admin" ) { %>
                                Bienvenido de nuevo. Tienes el control total de tu inventario.
                                <% } else if (Session["Rol"] !=null && Session["Rol"].ToString()=="Cliente" ) { %>
                                    Es un gusto tenerte de vuelta. Revisa nuestras ofertas hoy mismo.
                                    <% } else { %>
                                        Bienvenido. Por favor, identificate para continuar.
                                        <% } %>
                        </p>
                    </div>
                </div>
            </div>
        </main>
    </asp:Content>