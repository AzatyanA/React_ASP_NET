const Router = ReactRouterDOM.BrowserRouter;
const Route = ReactRouterDOM.Route;
const Switch = ReactRouterDOM.Switch;
const Link = ReactRouterDOM.Link;
const NavLink = ReactRouterDOM.NavLink;
class Employees extends React.Component {
    constructor(props) {
        super(props);
        this.state = { employees: [] };
    }

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.getUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ employees: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }

    render() {
        return (
            <div>
                <h1>Employees</h1>
                {
                    this.state.employees.map(function (employee) {

                        return <Employee key={employee.id} employee={employee} />
                    })
                }
            </div>);
    }
}
class Employee extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.employee };
    }
    render() {
        return (<div>
            <table border="2">
                <tr>
                    <td width="150">{this.state.data.EmployeeID}</td>
                    <td width="150">{this.state.data.LastName}</td>
                    <td width="150">{this.state.data.FirstMidName}</td>
                    <td width="150">{this.state.data.Position}</td>
                    <td width="150">{this.state.data.Age}</td>
                </tr>
            </table>
        </div>);
    }
}
ReactDOM.render(
    <Employees getUrl="/get" />,
    document.getElementById("content")
);

// api не работает ((

//ReactDOM.render(
//    <Employees getUrl="/api/ApiEmployee" />,
//    document.getElementById("content")
//);


// React Routing не сработал ((


//ReactDOM.render(
//    <Router>
//        <Switch>
//            <Route exact path="/" component={Employees} [getUrl = "/get"] />
//            <Route path="/getcandidates" component={Candidates} [getUrl = "/getcandidates"] />
//        </Switch>
//    </Router>,
//    document.getElementById("content")
//);