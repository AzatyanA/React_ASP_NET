class CommentBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
    }
    loadCommentsFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }
   
    componentDidMount() {
        this.loadCommentsFromServer();
        window.setInterval(
            () => this.loadCommentsFromServer(),

        );
    }
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
            </div>
        );
    }
}

class CommentList extends React.Component {
    render() {
        const commentNodes = this.props.data.map(comment => (
            <Comment lastname={comment.LastName} key={comment.EmployeeID}>
                {comment.FirstMidName}
            </Comment>
        ));
        return <div className="commentList">{commentNodes}</div>;
    }
}
class Comment extends React.Component {
    rawMarkup() {
        const md = new Remarkable();
        const rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="comment">
                <h2 className="commentLastName">{this.props.lastname}</h2>

            </div>
        );
    }
}

class Main extends React.Component {
    render() {
        return <h2>Главная</h2>;
    }
}
class About extends React.Component {
    render() {
        return <h2>Help</h2>;
    }
}

//ReactDOM.render(
//    <Main />,
//    document.getElementById('content'),
//);
ReactDOM.render(
    <CommentBox
        url="/get"
    />,
    document.getElementById('content'),
);

