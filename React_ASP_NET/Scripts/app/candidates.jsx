class Candidates extends React.Component {
    constructor(props) {
        super(props);
        this.state = { candidates: [] };
    }

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.getUrl, true);
        xhr.onload = function () {
            const data = JSON.parse(xhr.responseText);
            this.setState({ candidates: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }

    render() {
        return (
            <div>
                <h1>Candidates:</h1>
                {
                    this.state.candidates.map(function (candidate) {

                        return <Candidate key={candidate.Id} candidate={candidate} />
                    })
                }
            </div>);
    }
}
class Candidate extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.candidate };
    }
    render() {
        return (<div>
            <table border="2">
                <tr>
                    <td width="150">{this.state.data.CandidateID}</td>
                    <td width="150">{this.state.data.LastName}</td>
                    <td width="150">{this.state.data.FirstMidName}</td>
                    <td width="150">{this.state.data.Experience}</td>
                    <td width="150">{this.state.data.Age}</td>
                </tr>
            </table>
        </div>);
    }
}
ReactDOM.render(
    <Candidates getUrl="/getcandidates" />,
    document.getElementById("content")
);


// api не работает ((

//ReactDOM.render(
//    <Candidates getUrl="/api/apicandidate" />,
//    document.getElementById("content")
//);