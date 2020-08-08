@using OnlineShopBooks.Core
@model IEnumerable<OnlineShopBooks.Models.Book>

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

@if (User.IsInRole("Admin"))
{
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
}
<table class="table">
    <tr>
        <th>
            @Html.ActionLink("Title", "Index", new { sort = ViewBag.SortOrderTitle })
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Author)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Pages)
        </th>
        <th>
            @Html.ActionLink("Price", "Index", new { sort = ViewBag.SortOrderPrice })
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Count)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    if (item.Count != 0)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Title)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Author)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Description)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Pages)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Price) PLN
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Count)
            </td>
            <td>
                @if (User.IsInRole("Admin"))
                {
                    @Html.ActionLink("Edit", "Edit", new {id = item.Id})
                    <span> </span>
                    @Html.ActionLink("Delete", "Delete", new {id = item.Id})
                    <span> </span>
                }
                @Html.ActionLink("Details", "Details", new {id = item.Id})
                @if (User.IsInRole("Customer"))
                {
                    @Html.ActionLink("Add to Cart", "Add", "Cart", new {type = "Book", id = item.Id, quantity = 1}, null)
                }
            </td>
        </tr>
    }
}

</table>
