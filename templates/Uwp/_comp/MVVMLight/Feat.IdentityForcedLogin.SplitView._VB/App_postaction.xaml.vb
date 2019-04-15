﻿'{[{
Imports Param_RootNamespace.Core.Helpers
Imports Param_RootNamespace.Core.Services
'}]}
Public NotInheritable Partial Class App
    Inherits Application

'{[{
    Private ReadOnly Property IdentityService As IdentityService
        Get
            Return Singleton(Of IdentityService).Instance
        End Get
    End Property
'}]}

    Public Sub New()
        _activationService = New Lazy(Of ActivationService)(CreateActivationService)
'^^
'{[{
        AddHandler IdentityService.LoggedOut, AddressOf OnLoggedOut
'}]}
    End Sub

'^^
'{[{
    Private Async Sub OnLoggedOut(sender As Object, e As EventArgs)
        ActivationService.SetShell(New Lazy(Of UIElement)(CreateShell))
        Await ActivationService.RedirectLoginPageAsync()
    End Sub
'}]}
End Class
