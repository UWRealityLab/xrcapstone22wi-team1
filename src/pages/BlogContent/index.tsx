import { useEffect, useState } from "react";
import ReactMarkdown from "react-markdown";
import { useParams } from "react-router";
import "github-markdown-css/github-markdown-light.css";

const BlogContent = () => {
    const [content, setContent] = useState("");
    const { week } = useParams();

    useEffect(() => {
        fetch(require(`../../blogs/week${week}.md`))
            .then((res) => {
                return res.text();
            })
            .then((res) => {
                setContent(res);
                console.log(res);
            })
            .catch((err) => {
                setContent("## Error occurred...");
            });
    }, [week]);

    return (
        <div className="markdown-body">
            <ReactMarkdown>{content}</ReactMarkdown>
        </div>
    );
};

export default BlogContent;
